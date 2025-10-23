namespace Totvs.TesteFullStack.API.Entities
{
    public class Retorno
    {
        public Retorno() { }

        public Retorno(bool resultadoOperacao, int codigo, string mensagem)
        {
            this.ResultadoOperacao = resultadoOperacao;
            this.Codigo = codigo;
            this.Mensagem = mensagem;
        }

        public bool ResultadoOperacao { get; set; }
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}
