import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormErrorComponent } from "../../shared/form-error/form-error.component";
import { Subject, delay, takeUntil } from 'rxjs';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [ReactiveFormsModule, FormErrorComponent, CommonModule],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css'
})
export class CadastroComponent {
  formData = this.fb.group({
    email: ['', [Validators.required, Validators.pattern(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    username: ['', Validators.required]
  })
  unsubscribeSignal: Subject<void> = new Subject();
  isLoading: boolean = false;

  constructor(private fb: FormBuilder,
    private authService: AuthService, 
    private router: Router){}

  fieldHasRequiredError(fieldName: string) {
    return this.formData.get(fieldName)?.hasError('required') && this.formData.get(fieldName)?.touched;
  }

  fieldHasPatternError(fieldName: string) {
    if (this.formData.get(fieldName)?.hasError('pattern') && !(this.formData.get(fieldName)?.hasError('required')) && this.formData.get(fieldName)?.touched) {
      return true;
    }
    return false;
  }

  ngOnDestroy(): void {
    this.unsubscribeSignal.next()
    this.unsubscribeSignal.unsubscribe()
  }

  onSubmit() {
    this.formData.markAllAsTouched();
    if (this.formData.valid) {
      this.isLoading = true;
      let values = this.formData.value;
      if (values.email && values.username && values.password) {
        this.authService.registerUser(values.username, values.email, values.password)
          .pipe(
            takeUntil(this.unsubscribeSignal)
          )
          .subscribe({
            complete: () => {
              this.isLoading = false; 
              this.router.navigateByUrl('login');
            },
            error: () => {
              this.isLoading = false; 
            }
          });
      }
    }
  }
}
