import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormErrorComponent } from "../../shared/form-error/form-error.component";
import { Subject, takeUntil } from 'rxjs';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';
import { LocalStorageService } from '../../../services/local-storage.service';
import { JwtResponse } from '../../../models/JwtResponse';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, FormErrorComponent, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnDestroy {
  formData = this.fb.group({
    email: ['', [Validators.required, Validators.pattern(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
    password: ['', Validators.required],
  })
  unsubscribeSignal: Subject<void> = new Subject();
  isLoading: boolean = false;

  ngOnDestroy(): void {
    this.unsubscribeSignal.next()
    this.unsubscribeSignal.unsubscribe()
  }

  constructor(private fb: FormBuilder, 
    private authService: AuthService, 
    private router: Router,
    private localStorageService: LocalStorageService) { }

  fieldHasRequiredError(fieldName: string) {
    return this.formData.get(fieldName)?.hasError('required') && this.formData.get(fieldName)?.touched;
  }

  onSubmit() {
    this.formData.markAllAsTouched();
    if (this.formData.valid) {
      let values = this.formData.value;
      if (values.email && values.password) {
        this.authService.login(values.email, values.password).pipe(
          takeUntil(this.unsubscribeSignal))
          .subscribe({
            next: (res: JwtResponse) => {
              if (this.localStorageService.clear()) {
                this.localStorageService.set("jwt", res.jwt)
                this.localStorageService.set("expireDate", (Date.now().toString()))

                this.router.navigateByUrl('')
              }
            },
          })
      }
    }
  }
}
