import { map } from "rxjs/operators";
import { AppSettings } from "./app.settings";
import { ConfigurationService } from "./services/configuration.service";

export const appInitializerFn = (configService: ConfigurationService, appSettings: AppSettings) => {
    return (): Promise<boolean> => {
        return configService.loadConfig()
            .pipe(
                map(config => {
                    Object.assign(appSettings, config);
                    return true;
                })
            ).toPromise();  // return only after config is loaded
    };
};
