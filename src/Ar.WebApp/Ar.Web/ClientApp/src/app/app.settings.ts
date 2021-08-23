import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class AppSettings {

    public readonly apiUrl = this.getBaseUrl();

    private getBaseUrl(): string {
        return document.getElementsByTagName('base')[0].href;
    }

    public authScopes: string;
    public clientId: string;
    public identityUrl: string;
    public serviceGatewayUrl: string;
    public appTitle: string;
    public appLogo: string;
};
