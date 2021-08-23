import {DialogButton} from './dialog-button.enum';
import {MessageBoxIcon} from './message-box-icon.enum';

export class MessageBoxArgs {
  title: string;
  header: string;
  message: string;
  buttons: DialogButton;
  icon: MessageBoxIcon;
}
