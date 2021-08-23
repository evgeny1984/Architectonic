import { Injectable } from "@angular/core";
import { ProgressBarStatus } from '@bol/progressbar-status';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ProgressBarService {

    public status$ = new BehaviorSubject<ProgressBarStatus>({
        message: "",
        visible: false,
        position: "center",
        shading: true
    });


    public show(message: string, placeAtBottom?: boolean, noShading?: boolean) {
        this.status$.next(
            Object.assign(new ProgressBarStatus(), {
                message: message,
                visible: true,
                position: placeAtBottom === true ? 'bottom' : (placeAtBottom === false ? 'center' : this.status$.value.position),
                shading: noShading === true ? true : noShading === false ? false : this.status$.value.shading
            })
        );
    }

    public setProgress(message: string) {
        this.status$.next(
            Object.assign(new ProgressBarStatus(),
                this.status$.value,
                { message: message }
            )
        );
    }

    public hide() {
        this.status$.next(
            Object.assign(new ProgressBarStatus(),
                this.status$.value,
                {
                    message: '',
                    visible: false
                })
        );
    }

}
