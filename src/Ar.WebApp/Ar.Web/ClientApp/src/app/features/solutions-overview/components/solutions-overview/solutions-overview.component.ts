import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular/ui/data-grid';
import { Solution } from '@models/solution.model';
import dxButton from 'devextreme/ui/button';
import { ProgressBarService } from '@services/progressbar.service';
import { SolutionsOverviewService } from '../../services/solutions-overview.service';
import { NavigationExtras, Router } from '@angular/router';
import notify from 'devextreme/ui/notify';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-solutions-overview',
  templateUrl: './solutions-overview.component.html',
  styleUrls: ['./solutions-overview.component.scss']
})
export class SolutionsOverviewComponent implements OnInit {
  public solutions: Array<Solution>;
  public selectedSolution: Solution;
  public gridHeight: number = 560;
  public downloadEnabled: boolean = false;
  public btnExportInstance: dxButton;
  public btnDownloadInstance: dxButton;
  @ViewChild('solutionsGrid', { static: true }) dataGrid: DxDataGridComponent;


  constructor(
    private progressbarService: ProgressBarService,
    private solutionService: SolutionsOverviewService,
    private cdr: ChangeDetectorRef,
    private router: Router) {
    this.solutions = new Array<Solution>();

  }

  ngOnInit(): void {
    this.loadSolutions();
  }

  onToolbarPreparing(e) {
    let toolbarItems = e.toolbarOptions.items;

    // Add new items
    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "refresh",
        onClick: this.refreshSolutions.bind(this),
        hint: 'Refresh'
      },
      location: "after"
    });

    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "plus",
        onClick: this.createNewSolution.bind(this),
        hint: 'New solution'
      },
      location: "after"
    });

    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "download",
        disabled: !this.downloadEnabled,
        onClick: this.downloadSelectedSolution.bind(this),
        hint: 'Download solution',
        onInitialized: (args: any) => {
          this.btnDownloadInstance = args.component;
        },
      },
      location: "after"
    });

    toolbarItems.push({
      widget: "dxButton",
      options: {
        icon: "trash",
        onClick: this.deleteSelectedSolution.bind(this),
        hint: 'Delete process'
      },
      location: "after"
    });
  }

  public refreshSolutions() {
    this.loadSolutions();
  }

  private async loadSolutions() {
    this.progressbarService.show('Loading solutions...');
    this.solutions = await this.solutionService.getAllSolutions().toPromise();
    this.progressbarService.hide();
  }

  public createNewSolution() {
    // Navigate to the diagram page and create a new process diagram
    this.router.navigate(['/adl-editor']);
  }

  public deleteSelectedSolution() {
    if (this.selectedSolution) {
      this.solutionService.deleteSolution(this.selectedSolution.id).subscribe(
        (result: string) => {
          notify("Selected solution was deleted.", "success", 600);
          this.loadSolutions();
        },
        error => {
          console.log(error);
        });

    }
  }

  onSelectSolution(event) {
    if (event) {
      this.selectedSolution = event.data;
      this.downloadEnabled = true;
      if (this.btnExportInstance) {
        this.btnExportInstance.option({
          disabled: false
        });
      }
      if (this.btnDownloadInstance) {
        this.btnDownloadInstance.option({
          disabled: false
        });
      }
    }
  }

  public openSelectedSolution(event) {
    if (event) {
      let selectedSolution: Solution = event.data;
      if (selectedSolution) {
        let navigationExtras: NavigationExtras = {
          queryParams: {
            "selectedSolutionId": selectedSolution.id,
            "adlContent": selectedSolution.adlContent
          }
        };
        this.router.navigate(['/adl-editor'], navigationExtras);
      }

    }
  }

  public async downloadSelectedSolution() {

    if (this.selectedSolution) {
      const fileName = `${this.selectedSolution.name}.adl`;
      saveAs(new Blob([this.selectedSolution.adlContent], { type: 'application/txt' }), fileName);
    }
  }
}
