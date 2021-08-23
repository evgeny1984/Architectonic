import { Component, Input } from '@angular/core';
import { DialogResult } from '@bol/dialog-result.enum';
import { ProcessDefinition } from '@models/process-definition.model';
import { ProcessDefinitionMessage } from '@models/pd-message.model';
import { VariableData } from '@models/variable-data.model';

@Component({
  selector: 'app-send-camunda-message',
  templateUrl: './send-camunda-message.component.html',
  styleUrls: ['./send-camunda-message.component.scss']
})
export class SendCamundaMessageComponent {
  @Input() public selectedProcessDefinition: ProcessDefinition;
  @Input() public callback: Function;
  isVisible = false;
  public messageName: string;
  public variableName: string;
  public variableValue: string;

  constructor() {
  }

  // Show the dialog to initialize the bound data
  showDialog(): void {
    this.isVisible = true;
    this.messageName = "";
    this.variableName = "";
    this.variableValue = "";
  }

  // #region Events

  // Handle the ok button click
  validateOK(params) {
    this.isVisible = false;
    let message: ProcessDefinitionMessage = new ProcessDefinitionMessage();
    let data: VariableData = new VariableData();
    data.name = this.variableName;
    data.value = this.variableValue;
    message.messageName = this.messageName;
    message.data = data;
    message.businessKey = "1";
    message.processInstanceId = this.selectedProcessDefinition.id;
    this.callback(DialogResult.OK, message);
  }

  // Handle the cancel button click
  onClickCancel(e): void {
    this.isVisible = false;
    this.callback(DialogResult.Cancel, null);
  }

  /**
     * Set the value from the textbox to the actionvalue
     * @param data The data args from the textbox
     */
  valueChanged(data) {
    this.messageName = data.value;
  }

  variableNameChanged(name) {
    this.variableName = name.value;
  }

  variableValueChanged(value) {
    this.variableValue = value.value;
  }
}
