﻿using Store.Core.DomainObjects;

namespace Store.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            AssertionConcern.ValidarSeMenorQue(altura, 1, "O campo Altura não pode ser menor ou igual a 0");
            AssertionConcern.ValidarSeMenorQue(largura, 1, "O campo Largura não pode ser menor ou igual a 0");
            AssertionConcern.ValidarSeMenorQue(profundidade, 1, "O campo Profundidade não pode ser menor ou igual a 0");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
