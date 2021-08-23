import _Modeler from 'bpmn-js/lib/Modeler';
/**
 * You may include a different variant of BpmnJS:
 *
 * bpmn-viewer  - displays BPMN diagrams without the ability
 *                to navigate them
 * bpmn-modeler - bootstraps a full-fledged BPMN editor
 */
//import * as _Modeler from "bpmn-js/dist/bpmn-modeler.production.min.js";
import * as _PropertiesPanelModule from 'bpmn-js-properties-panel';
import * as _BpmnPropertiesProvider from 'bpmn-js-properties-panel/lib/provider/bpmn';
import * as _CamundaPropertiesProvider from 'bpmn-js-properties-panel/lib/provider/camunda';
import * as _ElementTemplates from 'bpmn-js-properties-panel/lib/provider/camunda/element-templates';
import * as _CamundaModdleDescriptor from 'camunda-bpmn-moddle/resources/camunda.json';
import * as _EntryFactory from 'bpmn-js-properties-panel/lib/factory/EntryFactory';
import _PaletteProvider from 'bpmn-js/lib/features/palette/PaletteProvider';
import _MinimapModule from 'diagram-js-minimap';

export const InjectionNames = {
  eventBus: 'eventBus',
  bpmnFactory: 'bpmnFactory',
  entryFactory: 'entryFactory',
  elementFactory: 'elementFactory',
  elementRegistry: 'elementRegistry',
  translate: 'translate',
  moddle: 'moddle',
  bpmnModdle: 'bpmnModdle',
  propertiesProvider: 'propertiesProvider',
  elementTemplates: 'elementTemplates',
  paletteProvider: 'paletteProvider',
  originalPaletteProvider: 'originalPaletteProvider'
};

export const Modeler = _Modeler;
export const PropertiesPanelModule = _PropertiesPanelModule;
export const EntryFactory = _EntryFactory;
export const OriginalPaletteProvider = _PaletteProvider;
export const OriginalPropertiesProvider = _BpmnPropertiesProvider;
export const ElementTemplates = _ElementTemplates;
export const CamundaPropertiesProvider  = _CamundaPropertiesProvider;
export const MinimapModule = _MinimapModule;
export const CamundaModdleDescriptor = _CamundaModdleDescriptor;

export interface IPaletteProvider {
  getPaletteEntries(): any;
}

export interface IPalette {
  registerProvider(provider: IPaletteProvider): any;
}

export interface IPropertiesProvider {
  getTabs(elemnt): any;
}
