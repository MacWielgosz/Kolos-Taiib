import { Component } from '@angular/core';
import { KlawiaturyServiceService } from '../klawiatury-service.service';
import { KlawiaturaResponceDTO } from '../Model/KlawiaturaResponce.interface';
import { KlawiaturyRequestDTO } from '../Model/KlawiaturyRequestDTO.interface';
import { KeyboardType } from '../Model/KeyboardType';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-klawiatury',
  templateUrl: './klawiatury.component.html',
  styleUrl: './klawiatury.component.css'
})
export class KlawiaturyComponent {
  data : KlawiaturaResponceDTO[]=[];
  
  public model: string;
  public rodzaj: KeyboardType;
  keyboardTypes = KeyboardType;

  togle:boolean = true;
  constructor(private service:KlawiaturyServiceService){
    this.getData();
    
    this.model = '';
    this.rodzaj = 1;
  }
  private getData(): void {
    this.service.get().subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }
  Toggle(){
    this.togle = !(this.togle);
  }
  onDelete(id: number): void {
    this.service.delete(id)
      .subscribe(() => {
        this.data = this.data.filter(k => k.id !== id);
      });
  }
  onSubmit(): void {
    const body: KlawiaturyRequestDTO = {
      model: this.model,
      type: Number( this.rodzaj)
    };
    this.service.post(body)
      .subscribe(
        () => {
          console.log('Dodano nową klawiaturę');
          this.Toggle();
          this.getData();
        }
      );
      
  }
  getKeyboardTypeValues(): number[] {
    return Object.values(this.keyboardTypes).filter(value => typeof value === 'number') as number[];
  }
}
