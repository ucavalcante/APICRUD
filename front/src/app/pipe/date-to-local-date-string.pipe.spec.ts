import { DateToLocalDateStringPipe } from './date-to-local-date-string.pipe';

describe('DateToLocalDateStringPipe', () => {
  it('create an instance', () => {
    const pipe = new DateToLocalDateStringPipe();
    expect(pipe).toBeTruthy();
  });
});
