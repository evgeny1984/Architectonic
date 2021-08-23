import { Component, Input, OnInit } from '@angular/core';
import { MessageBoxArgs } from '@bol/message-box-args';
import { DialogButton } from '@bol/dialog-button.enum';
import { DialogResult } from '@bol/dialog-result.enum';


@Component({
    selector: 'app-msgbox',
    templateUrl: './messagebox.component.html',
    styleUrls: ['./messagebox.component.css'],
})
export class MessageBoxComponent implements OnInit {
    @Input() messageBoxArgs: MessageBoxArgs;
    @Input() callback: Function;
    isVisible = false;

    constructor() {

    }

    private get isOkButtonVisible(): boolean {
        return this.messageBoxArgs.buttons === DialogButton.OKCancel || this.messageBoxArgs.buttons === DialogButton.OK;
    }

    private get isYesButtonVisible(): boolean {
        return this.messageBoxArgs.buttons === DialogButton.YesNo || this.messageBoxArgs.buttons === DialogButton.YesNoCancel;
    }

    private get isCancelButtonVisible(): boolean {
        return this.messageBoxArgs.buttons === DialogButton.Cancel
            || this.messageBoxArgs.buttons === DialogButton.YesNoCancel
            || this.messageBoxArgs.buttons === DialogButton.OKCancel;
    }

    private get isNoButtonVisible(): boolean {
        return this.messageBoxArgs.buttons === DialogButton.YesNoCancel || this.messageBoxArgs.buttons === DialogButton.YesNo;
    }

    ngOnInit() {
        this.messageBoxArgs = new MessageBoxArgs();
        this.messageBoxArgs.buttons = DialogButton.YesNo;
    }

    showDialog(): void {
        this.isVisible = true;
    }

    onClickOK(): void {
        this.isVisible = false;
        this.callback(DialogResult.OK);
    }

    onClickYes(): void {
        this.isVisible = false;
        this.callback(DialogResult.Yes);
    }

    onClickCancel(): void {
        this.isVisible = false;
        this.callback(DialogResult.Cancel);
    }

    onClickNo(): void {
        this.isVisible = false;
        this.callback(DialogResult.No);
    }

}
