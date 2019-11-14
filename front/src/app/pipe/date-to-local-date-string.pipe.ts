import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateToLocalDateString'
})
export class DateToLocalDateStringPipe implements PipeTransform {

  transform(value: Date): string {
    return new Date(value).toLocaleDateString();
  }
}
