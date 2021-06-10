using System;

namespace DIO.Bank
{
	public class Conta //Criar a classe conta
	{
		// Criar Atributos da classe conta
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }

		// Métodos referente a classe conta
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}

		public bool Sacar(double valorSaque) //Criar método Sacar
		{
            if (this.Saldo - valorSaque < (this.Credito *-1)) // Validar se há saldo disponivel para a operação.
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
         
            return true;
		}

		public void Depositar(double valorDeposito) //Criar o método Depositar
		{
			this.Saldo += valorDeposito; //Adicionar o valor depositado ao saldo atual.

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino) // Criar método transferir
		{
			if (this.Sacar(valorTransferencia)){ // "Sacar" da conta de origem e "depositar" na conta de destino
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString() // Sobreescrever as informações do método ToString para exibir na tela.
		{
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}
	}
}