import * as Eta from 'eta';
import * as Ejs from 'ejs';

var addNumbers: any = (callback, first, second) => {
    var result = first + second;
    callback(/* error */ null, result);
};

var renderTemplate: any = (callback, answer) => {
    var result = Eta.render('Number <%= it.answer %>', { answer: answer });
    callback(/* error */ null, result);
};

export {
    addNumbers,
    renderTemplate
}