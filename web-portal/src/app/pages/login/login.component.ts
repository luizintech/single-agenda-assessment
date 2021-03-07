import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public authForm: FormGroup;

  public email: string = "";
  public password: string = "";

  constructor(private formBuilder: FormBuilder) { 
    this.authForm = this.formBuilder.group({
      email:  ['', Validators.required], 
      password:  ['', Validators.required]                
    }); 
  }

  ngOnInit(): void {
  }

  login() {
    console.log('login')
    if(this.authForm.valid){
      // var produto = this.populateProduto();
      // this.produtoTransacaoService.add(produto).subscribe((resultado: Resultado) => {
      //   if (resultado.Sucesso) {
      //     alert('Aplicação incluida com sucesso!');
      //     this.router.navigate(['dashboard']);
      //   } else {
      //     alert('Possíveis erros ocorreram ao tentar incluir um produto. \r\n' 
      //       + resultado.Mensagens);
      //   }
      // });
      
    } else {
      // alert('Preencha corretamente todos os campos.')
    }
  }

  // private populate(): Produto {
  //   var produto = new Produto();
  //   produto.Id = this.produtoId;
  //   produto.PrecoUnitario = this.preco;
  //   produto.Qtde = this.qtde;
  //   produto.TaxaCorretagem = this.taxaCorretagem;
  //   produto.DataInicio = this.dataInicio;
  //   return produto;
  // }

}
