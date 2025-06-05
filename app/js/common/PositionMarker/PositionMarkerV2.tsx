import { CSSProperties, forwardRef, Ref } from 'react';
import styled from 'styled-components';
import { AdvancedMarker } from '@vis.gl/react-google-maps';

const MarkerWrapper = styled.div`
    position: relative;
    user-select: none;
    cursor: default;
    width: 16px;
    height: 16px;
`;

interface MarkerProps {
    color: string;
}

const Marker = styled.div<MarkerProps>`
    display: flex;
    align-items: center;
    justify-content: center;
    height: 16px;
    width: 16px;
    border-radius: 50%;
    background-color: ${(props) => props.color};
    border: 1px solid white;
    padding: 0;
`;

const MarkerCenter = styled.div`
    height: 4px;
    width: 4px;
    border-radius: 50%;
    background-color: white;
`;

interface PositionMarkerV2Props {
    color: string;
    style?: CSSProperties;
    lat: number;
    lng: number;
}

export const PositionMarkerV2 = forwardRef(
    ({ style, color, lat, lng, ...rest }: PositionMarkerV2Props, ref: Ref<HTMLDivElement>) => (
        <AdvancedMarker position={{ lat, lng }} {...rest}>
            <MarkerWrapper ref={ref} style={style}>
                <Marker color={color}>
                    <MarkerCenter />
                </Marker>
            </MarkerWrapper>
        </AdvancedMarker>
    )
);

PositionMarkerV2.displayName = 'PositionMarkerV2';

