import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { ProgressBarService } from '@services/progressbar.service';
import { Subscription } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
    selector: 'app-progress-bar',
    templateUrl: 'progressbar.component.html',
    styleUrls: ['progressbar.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProgressBarComponent {

    private subscription: Subscription;

    public visible = false;
    public message = '';
    public shading = true;
    public position = 'center';

    constructor(progressBarService: ProgressBarService, private cdr: ChangeDetectorRef) {
        // Loading panel service subscription
        this.subscription = progressBarService.status$
            .pipe(debounceTime(400))  // delay message to minimize flickering
            .subscribe(status => {
                if (status) {
                    this.visible = status.visible;
                    this.message = status.message;
                    this.shading = status.shading;
                    this.position = status.position;
                    this.cdr.markForCheck();
                }
            });
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }

}
