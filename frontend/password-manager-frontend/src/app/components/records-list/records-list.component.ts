import { Component } from '@angular/core';
import { IRecords } from '../../model/records';
import { RecordService } from '../../services/record.service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { RecordFormComponent } from '../record-form/record-form.component';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-records-list',
  standalone: true,
  imports: [MatTableModule, MatButtonModule,RouterLink, FormsModule, MatIconModule, DatePipe],
  providers: [DatePipe],
  templateUrl: './records-list.component.html',
  styleUrl: './records-list.component.css'
})
export class RecordsListComponent {
recordsList:IRecords[] = [];
showPassword: boolean[] = [];
searchQuery: string = '';
displayedColumns: string[] = ['name', 'password', 'dateCreated'];

constructor(public dialog: MatDialog, public recordService: RecordService) {}

ngOnInit(){
  this.recordService.getAllRecords().subscribe((result) => {
    this.recordsList = result;
    this.showPassword = result.map(() => false);
    console.log(this.recordsList);
  });
}

togglePasswordVisibility(index: number): void {
    this.showPassword[index] = !this.showPassword[index];
}

searchRecords(query: string): void{
  this.recordService.searchRecords(query).subscribe(records => {
    this.recordsList = records;
    this.showPassword = this.recordsList.map(() => false);
  });
}

resetSearch(): void {
  this.searchQuery = '';
  this.recordService.getAllRecords().subscribe(records => {
    this.recordsList = records;
    this.showPassword = this.recordsList.map(() => false);
  });
}

openAddRecordDialog(): void {
  const dialogRef = this.dialog.open(RecordFormComponent, {
    width: '450px'
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      this.resetSearch();
    }
  });
}

}
