﻿using Store.Core.DomainObjects;

namespace Store.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF Relation
        public ICollection<Produto> Produtos { get; set; }

        protected Categoria() { }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            AssertionConcern.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }
    }
}