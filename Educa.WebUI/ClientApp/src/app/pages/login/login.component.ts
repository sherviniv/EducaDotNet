import { Component, OnInit } from '@angular/core';
import { LoginDto } from '../../EducaDotNet-api';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../core/services';
import { map, first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: LoginDto;
  returnUrl: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService) {
    this.model = {} as LoginDto;
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {


    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onsubmit(f) {

    if (!f.valid) {
      return;
    }

    this.authenticationService.login(this.model)
      .pipe(first())
      .subscribe(
        () => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
          
        });

  }

}
