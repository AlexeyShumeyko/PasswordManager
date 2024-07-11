import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Record, RecordType } from '../../model/records';
import { RecordService } from '../../services/record.service';
import { MatDialogRef } from '@angular/material/dialog';
import { MatRadioModule } from '@angular/material/radio';

@Component({
  selector: 'app-record-form',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, ReactiveFormsModule, MatRadioModule],
  templateUrl: './record-form.component.html',
  styleUrl: './record-form.component.css'
})
export class RecordFormComponent {
  recordForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private recordService: RecordService,
    public dialogRef: MatDialogRef<RecordFormComponent>,
  ) {
    this.recordForm = this.fb.group({
      name: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(8)]],
      recordType: [RecordType.Website, Validators.required],
    });
  }

  onSubmit(): void {
    if (this.recordForm.valid) {
      const formValue = this.recordForm.value;

      const newRecord: Record = {
        ...formValue,
        recordType: Number(formValue.recordType)
      };

      this.recordService.addRecord(newRecord).subscribe({
        next: (record) => {
          this.dialogRef.close(record);
        },
        error: (err) => {
          switch (err.status) {
            case 501:
              alert('Запись с таким именем уже существует');
              break;
            case 502:
              alert('Неверный формат электронной почты');
              break;
            default:
              console.error('Произошла ошибка:', err);
              alert('Произошла внутренняя ошибка сервера');
          }
        }
      });
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
