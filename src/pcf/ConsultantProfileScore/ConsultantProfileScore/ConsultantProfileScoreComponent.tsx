import * as React from "react";

export interface IConsultantProfileScoreProps {
    profileScore?: number;
}

export class ConsultantProfileScoreComponent extends React.Component<IConsultantProfileScoreProps> {

    private getStatus(score: number): string {

        if (score >= 80) {
            return "Ready for Staffing";
        }

        if (score >= 50) {
            return "Developing Profile";
        }

        return "Needs Improvement";
    }

    private getColor(score: number): string {

        if (score >= 80) {
            return "#107C10";
        }

        if (score >= 50) {
            return "#FFB900";
        }

        return "#D13438";
    }

    public render(): React.ReactNode {

        const score = Math.max(
            0,
            Math.min(
                100,
                this.props.profileScore ?? 0
            )
        );

        const status =
            this.getStatus(score);

        const color =
            this.getColor(score);

        return (
            <div
                style={{
                    padding: "16px",
                    fontFamily: "Segoe UI",
                    width: "100%",
                    textAlign: "center",
                    boxSizing: "border-box"
                }}
            >
                <div
                    style={{
                        fontSize: "16px",
                        fontWeight: 600,
                        marginBottom: "12px"
                    }}
                >
                    Consultant Profile Score
                </div>

                <div
                    style={{
                        width: "100%",
                        maxWidth: "500px",
                        height: "20px",
                        backgroundColor: "#EDEBE9",
                        borderRadius: "10px",
                        overflow: "hidden",
                        margin: "0 auto 12px auto"
                    }}
                >
                    <div
                        style={{
                            width: `${score}%`,
                            height: "100%",
                            backgroundColor: color,
                            transition: "0.3s ease"
                        }}
                    />
                </div>

                <div
                    style={{
                        fontSize: "18px",
                        fontWeight: 600
                    }}
                >
                    {score} / 100
                </div>

                <div
                    style={{
                        color: color,
                        marginTop: "6px",
                        fontWeight: 600,
                        fontSize: "14px"
                    }}
                >
                    {status}
                </div>
            </div>
        );
    }
}