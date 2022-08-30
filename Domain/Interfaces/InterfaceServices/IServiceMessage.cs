﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceMessage
    {
        Task Adicionar(Message Objeto);

        Task Atualizar(Message Objeto);

        Task<List<Message>> ListarMessageAtivas();

    }
}
