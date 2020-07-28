import { Component, OnInit, Input, ContentChild, TemplateRef, ViewChild, EventEmitter } from '@angular/core';
import { Subject } from 'rxjs/internal/Subject';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { DataTableDirective } from 'angular-datatables';

@Component({
  selector: 'ed-grid',
  templateUrl: './ed-grid.component.html',
  styleUrls: ['./ed-grid.component.css']
})
export class EdGridComponent implements OnInit {

  @ContentChild(TemplateRef, {})
  layoutTemplate: TemplateRef<any>;
  @Input("config") config: GridConfig;

  @ViewChild(DataTableDirective, { static: false })
  datatableElement: DataTableDirective;

  dtOptions: DataTables.Settings = {};
  startPoint: number;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {

  }

  ngAfterContentInit() {
    const cf = this.config;
    cf.serverUrl = environment.apiUrl + cf.serverUrl;
    cf.options = {
      serverSide: cf.serverSide,
      lengthMenu: [10, 25, 50],
      paging: true,
      pagingType: 'simple_numbers',
      columns: cf.columns,
      searching: true,
      order: []
    };


  }

  ngAfterViewInit(): void {
    var self = this;
    const cf = this.config;
    
    if (cf.serverSide) {
      this.loadServerSide();
    }
    else {
      this.loadClientSide();
    }

    this.addSearchInputs();

    self.config.refresh = function () {

      if (cf.serverSide) {
        self.datatableElement.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.draw();
        });
      }
      else
        self.loadClientSide();
    }

  }

  loadServerSide() {
    const cf = this.config;
    cf.options.ajax = (dataTablesParameters: any, callback) => {
      this.http
        .post<DataTablesResponse>(cf.serverUrl, dataTablesParameters, {})
        .subscribe(resp => {
          cf.data = resp.data;
          this.startPoint = dataTablesParameters.start + 1;
          callback({
            recordsTotal: resp.recordsTotal,
            recordsFiltered: resp.recordsFiltered,
            data: []
          });
        });
    }
  }

  loadClientSide() {
    const cf = this.config;
            
    this.http.post<any>(cf.serverUrl, {}, {}).subscribe(
      resp => {
        cf.data = resp.data;
        this.datatableElement.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.draw();
        });
      });
  }

  addSearchInputs() {
    const self = this;
    const cf = self.config;

    $(`#${cf.id} thead tr`).clone(true).appendTo(`#${cf.id} thead`);
    const searchHeaders = $(`#${cf.id} thead tr:eq(0) th`);

    this.datatableElement.dtInstance.then((dtInstance: DataTables.Api) => {

      //Render search box
      dtInstance.columns().every(function (i) {

        const column = cf.columns[i];
        $(searchHeaders[i]).html(column.searchable ?
          '<input class="form-control form-control-sm" type="text" placeholder="Search ' + column.title + '" />'
          : '');


        const header = this;
        $('input', searchHeaders[i]).on('keyup change', function () {

          if (header.search() !== this['value']) {
            dtInstance
              .column(i)
              .search(this['value'])
              .draw();
          }

        });
      });

      //dtInstance.on('order.dt search.dt', function () {
      //  dtInstance.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
      //    cell.innerHTML = i + 1;
      //  });
      //}).draw();

    });
  }
}

export class GridConfig {
  id: string;
  title: string;
  serverSide: boolean;
  serverUrl: string;
  data?: any[];
  options?: DataTables.Settings;
  columns: DataTables.ColumnSettings[];
  refresh?: () => void;
}

class DataTablesResponse {
  data: any[];
  draw: number;
  recordsFiltered: number;
  recordsTotal: number;
}

