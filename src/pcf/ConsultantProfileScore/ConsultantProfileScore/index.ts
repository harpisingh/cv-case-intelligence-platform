import { IInputs, IOutputs } from "./generated/ManifestTypes";
import {
    ConsultantProfileScoreComponent,
    IConsultantProfileScoreProps
} from "./ConsultantProfileScoreComponent";

import * as React from "react";

export class ConsultantProfileScore implements ComponentFramework.ReactControl<IInputs, IOutputs> {

    private notifyOutputChanged: () => void;

    constructor() {
        // Empty
    }

    public init(
        context: ComponentFramework.Context<IInputs>,
        notifyOutputChanged: () => void,
        state: ComponentFramework.Dictionary
    ): void {
        this.notifyOutputChanged = notifyOutputChanged;
    }

    public updateView(
        context: ComponentFramework.Context<IInputs>
    ): React.ReactElement {

        const props: IConsultantProfileScoreProps = {
            profileScore:
                context.parameters.profileScore.raw ?? 0
        };

        return React.createElement(
            ConsultantProfileScoreComponent,
            props
        );
    }

    public getOutputs(): IOutputs {
        return {};
    }

    public destroy(): void {
        // Cleanup if needed
    }
}