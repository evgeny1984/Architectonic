/// <reference path="../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AdlEditorComponent } from './adl-editor.component';

let component: AdlEditorComponent;
let fixture: ComponentFixture<AdlEditorComponent>;

describe('AdlEditor component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AdlEditorComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AdlEditorComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
