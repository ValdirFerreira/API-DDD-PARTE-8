using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _IMessage;

        public ServiceMessage(IMessage IMessage)
        {
            _IMessage = IMessage;
        }

        public async Task Adicionar(Message Objeto)
        {
            var validatitulo = Objeto.ValidarPropriedadeString(Objeto.Titulo, "Titulo");
            if (validatitulo)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.Ativo = true;
                await _IMessage.Add(Objeto);
            }
        }

        public async Task Atualizar(Message Objeto)
        {
            var validatitulo = Objeto.ValidarPropriedadeString(Objeto.Titulo, "Titulo");
            if (validatitulo)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IMessage.Update(Objeto);
            }
        }

        public async Task<List<Message>> ListarMessageAtivas()
        {
            return await _IMessage.ListarMessage(n => n.Ativo);
        }
    }
}
