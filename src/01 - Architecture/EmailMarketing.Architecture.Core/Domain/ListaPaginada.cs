namespace EmailMarketing.Architecture.Core.Domain
{
    public class ListaPaginada<T> : IListaPaginada where T : class
    {
        public ListaPaginada()
        {
            Lista = new List<T>();
        }

        public List<T> Lista { get; set; }
        public int RegistroInicial { get; set; }
        public int RegistroFinal { get; set; }
        public int TotalRegistros { get; set; }
        public int NumeroPaginas { get; set; }
        public int Pagina { get; set; }
        public int RegistrosPorPagina { get; set; }
        public string ReferenceAction { get; set; }
        public string Query { get; set; }

        public void CalcularRegistros()
        {
            if (Pagina <= 0)
            {
                Pagina = 1;
            }
            RegistroInicial = ((Pagina - 1) * RegistrosPorPagina) + 1;
            RegistroFinal = (RegistroInicial + RegistrosPorPagina) - 1;
            if (RegistroFinal == 0)
            {
                RegistroFinal = TotalRegistros;
            }
            else if (RegistroFinal > TotalRegistros)
            {
                RegistroFinal = TotalRegistros;
            }
            NumeroPaginas = (int)Math.Ceiling((double)TotalRegistros / RegistrosPorPagina);
            if (NumeroPaginas <= 0)
            {
                NumeroPaginas = 1;
            }
            if (Pagina > NumeroPaginas)
            {
                Pagina = NumeroPaginas;
            }
            if (RegistrosPorPagina == 0)
            {
                RegistrosPorPagina = TotalRegistros;
            }
            if (TotalRegistros == 0)
            {
                RegistroInicial = 0;
                NumeroPaginas = 0;
                Pagina = 0;
            }
        }
    }
    public interface IListaPaginada
    {
        public string ReferenceAction { get; set; }
        public string Query { get; set; }
        public int RegistroInicial { get; set; }
        public int RegistroFinal { get; set; }
        public int TotalRegistros { get; set; }
        public int NumeroPaginas { get; set; }
        public int Pagina { get; set; }
        public int RegistrosPorPagina { get; set; }
    }
}
