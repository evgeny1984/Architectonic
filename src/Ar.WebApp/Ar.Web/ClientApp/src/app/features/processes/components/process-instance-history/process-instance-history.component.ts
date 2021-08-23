import { ChangeDetectorRef, Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { HistoryProcessInstance } from '@models/history-process-instance.model';
import { DxDataGridComponent } from 'devextreme-angular';
import { CamundaService } from '@services/camunda.service';
import { ProgressBarService } from '@services/progressbar.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-process-instance-history',
  templateUrl: './process-instance-history.component.html',
  styleUrls: ['./process-instance-history.component.scss']
})
export class ProcessInstanceHistoryComponent implements OnInit {
  public processInstances: Array<HistoryProcessInstance>;
  public selectedprocessInstance: HistoryProcessInstance;
  public gridHeight: number = 560;
  public messageEnabled: boolean = false;
  @ViewChild('processInstancesGrid', { static: true }) dataGrid: DxDataGridComponent;

  constructor(private progressbarService: ProgressBarService,
    private camundaService: CamundaService,
    private cdr: ChangeDetectorRef,
    private router: Router) {
    this.processInstances = new Array<HistoryProcessInstance>();
  }

  ngOnInit(): void {
    this.loadProcessInstances();
  }

  ngAfterViewInit(): void {
    this.calculateGridHeight();
    this.cdr.detectChanges();
  }

  /**
* Handle the resize event to set the grid height
* @param $event The event args
*/
  @HostListener('window:resize', ['$event'])
  onResize(event?) {
    this.calculateGridHeight();
  }

  /**Calculate the data grid height dynamically based on the window height and element position */
  private calculateGridHeight(): void {
    this.gridHeight = window.innerHeight - this.dataGrid.instance.element().getBoundingClientRect().top - 5;
  }

  private loadProcessInstances() {
    this.progressbarService.show('Loading process instances...');
    this.camundaService.getProcessInstancesHistory().subscribe(
      (result: HistoryProcessInstance[]) => {
        this.processInstances = result;
        this.progressbarService.hide();
      },
      err => {
        this.progressbarService.hide();
      }
    );
  }

  customizeEndDateText(cellInfo) {
    let text = cellInfo.value == '0001-01-01T00:00:00' ? 'N/A' : new DatePipe('en-US').transform(cellInfo.value, 'short');;

    return text;
  }

}
