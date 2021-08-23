import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { MessageBoxComponent } from './messagebox.component';
import {DxButtonModule, DxPopupModule, DxTemplateModule} from 'devextreme-angular';

describe('MessageBoxComponent', () => {
  let component: MessageBoxComponent;
  let fixture: ComponentFixture<MessageBoxComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [
        DxPopupModule,
        DxButtonModule,
        DxTemplateModule,
      ],
      declarations: [ MessageBoxComponent ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessageBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
