import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from '../services';
import { ToastrService } from 'ngx-toastr';
import { ServerResult } from '../../EducaDotNet-api';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authenticationService: AuthenticationService, private toastr: ToastrService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError((err: HttpErrorResponse) => {

      err.error.text().then((reqBody) => {
        
        reqBody = reqBody && reqBody.length > 0 ? reqBody : null;
        const res: ServerResult = JSON.parse(reqBody);
        
        if (err.status === 500) {
          this.toastr.error(res.message,"Error");
        }

        if (err.status === 400) {
          this.toastr.warning(res.message);
        }

        if ([401, 403].indexOf(err.status) !== -1) {
          // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
          this.toastr.warning("Unauthorized request", err.status.toString());
          this.authenticationService.logout();
          location.reload(true);
        }

      });

      const error = err.error.message || err.statusText;
      return throwError(error);
    }))
  }

}
