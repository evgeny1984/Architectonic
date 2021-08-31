/// <reference path="../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { SolutionsOverviewComponent } from './solutions-overview.component';

let component: SolutionsOverviewComponent;
let fixture: ComponentFixture<SolutionsOverviewComponent>;

describe('SolutionsOverview component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ SolutionsOverviewComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SolutionsOverviewComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
