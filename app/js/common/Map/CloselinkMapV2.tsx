import { ReactNode, useCallback, useEffect, useRef } from 'react';
import { APIProvider, Map, useMap } from '@vis.gl/react-google-maps';

import AppSettings from '../../constants';
import { mapStyles } from './mapStyles';

export interface Position {
    lat: number;
    lng: number;
}

export interface Polyline {
    strokeWeight: number;
    strokeColor: string;
    path: Position[];
}

interface CloselinkMapV2Props {
    children?: ReactNode[];
    zoomControl?: boolean;
    defaultCenter?: Position;
    defaultZoom?: number;
    places?: Position[];
    polylines?: Polyline[];
    onDragEnd?: () => void;
    onDrag?: () => void;
    fitToBounds?: boolean;
    minZoom?: number;
    onApiIsLoaded?: () => void;
    center?: { lat: number; lng: number };
    zoom?: number;
}

// Component to handle polylines and bounds fitting
const MapController = ({
    places,
    polylines,
    fitToBounds,
    defaultZoom,
    defaultCenter,
    onApiIsLoaded,
}: {
    places?: Position[];
    polylines?: Polyline[];
    fitToBounds?: boolean;
    defaultZoom: number;
    defaultCenter: Position;
    onApiIsLoaded?: () => void;
}) => {
    const map = useMap();
    const polylinesRef = useRef<google.maps.Polyline[]>([]);

    const handleApiLoaded = useCallback(() => {
        if (!map) return;

        // Clear existing polylines
        polylinesRef.current.forEach(polyline => polyline.setMap(null));
        polylinesRef.current = [];

        // Add polylines
        if (polylines && polylines.length > 0) {
            polylines.forEach((polyline) => {
                const mapPolyline = new google.maps.Polyline({
                    path: polyline.path,
                    strokeColor: polyline.strokeColor,
                    strokeWeight: polyline.strokeWeight,
                });
                mapPolyline.setMap(map);
                polylinesRef.current.push(mapPolyline);
            });
        }

        // Handle bounds fitting
        if (fitToBounds) {
            const bounds = new google.maps.LatLngBounds();

            if (places && places.length > 0) {
                places.forEach((place) => {
                    bounds.extend(new google.maps.LatLng(place.lat, place.lng));
                });
            } else {
                bounds.extend(new google.maps.LatLng(defaultCenter.lat, defaultCenter.lng));
            }

            map.setCenter(bounds.getCenter());
            map.fitBounds(bounds);

            if (places && places.length === 1) {
                map.setZoom(10);
            }

            if (!places || places.length === 0) {
                map.setZoom(defaultZoom);
            }
        }

        // Call the onApiIsLoaded callback
        if (onApiIsLoaded) {
            onApiIsLoaded();
        }
    }, [map, places, polylines, fitToBounds, defaultZoom, defaultCenter, onApiIsLoaded]);

    useEffect(() => {
        if (map) {
            handleApiLoaded();
        }
    }, [handleApiLoaded]);

    // Cleanup polylines on unmount
    useEffect(() => {
        return () => {
            polylinesRef.current.forEach(polyline => polyline.setMap(null));
        };
    }, []);

    return null;
};

export const CloselinkMapV2 = ({
    places,
    children,
    defaultCenter = { lat: 0, lng: 0 },
    defaultZoom = 0,
    zoomControl = false,
    onDrag,
    onDragEnd,
    polylines,
    fitToBounds = false,
    minZoom = 0,
    onApiIsLoaded,
    center,
    zoom,
}: CloselinkMapV2Props) => {
    const handleDragStart = useCallback(() => {
        if (onDrag) {
            onDrag();
        }
    }, [onDrag]);

    const handleDragEnd = useCallback(() => {
        if (onDragEnd) {
            onDragEnd();
        }
    }, [onDragEnd]);

    return (
        <APIProvider apiKey={AppSettings.googleApiURLKey} libraries={['places']}>
            <Map
                defaultCenter={defaultCenter}
                defaultZoom={defaultZoom}
                center={center}
                zoom={zoom}
                minZoom={minZoom}
                disableDefaultUI={true}
                zoomControl={zoomControl}
                mapTypeId="roadmap"
                styles={mapStyles}
                onDragstart={handleDragStart}
                onDragend={handleDragEnd}
                gestureHandling="greedy"
                style={{ width: '100%', height: '100%' }}
            >
                <MapController
                    places={places}
                    polylines={polylines}
                    fitToBounds={fitToBounds}
                    defaultZoom={defaultZoom}
                    defaultCenter={defaultCenter}
                    onApiIsLoaded={onApiIsLoaded}
                />
                {children}
            </Map>
        </APIProvider>
    );
};

