namespace WebApi.Models
{
    // padronizar as respostas da aplicação, retornando dados, status da resposta e mensagem de erro se houver em json

    public class ResponseModel<T>  // tipo generico pois receberá dados tanto de AutorModel qto LivroModel, evita criar uma response model pra cada um
    {
        public T? Dados {get; set;} // pode ser nulo caso n encontre no banco e etc

        public string Mensagem { get; set; } = string.Empty;

        public bool status { get; set; } = true;
    }
}
