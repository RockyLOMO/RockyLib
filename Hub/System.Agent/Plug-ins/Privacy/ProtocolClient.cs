﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace System.Agent.Privacy
{
    internal class ProtocolClient : Disposable
    {
        private TcpClient _client;
        private volatile ConfigEntity _config;

        internal ConfigEntity Config
        {
            get
            {
                Contract.Ensures(Contract.Result<ConfigEntity>() != null);
                base.CheckDisposed();

                _client.Client.Send(new PackModel()
                {
                    Cmd = Command.GetConfig,
                });
                while (_config == null)
                {
                    Thread.Sleep(1000);
                }
                return _config;
            }
            set
            {
                Contract.Requires(value != null);
                base.CheckDisposed();

                _client.Client.Send(new PackModel()
                {
                    Cmd = Command.SetConfig,
                    Model = value
                });
            }
        }

        public ProtocolClient()
        {
            _client = new TcpClient();
            _client.Connect(PackModel.ServiceEndPoint);
            TaskHelper.Factory.StartNew(this.OnReceive);

            _client.Client.Send(new PackModel()
            {
                Cmd = Command.Auth,
                Model = "Rocky"
            });
        }
        protected override void DisposeInternal(bool disposing)
        {
            _client.Close();
        }

        private void OnReceive()
        {
            while (_client.Connected)
            {
                PackModel pack;
                _client.Client.Receive(out pack);
                switch (pack.Cmd)
                {
                    case Command.Auth:
                        bool ok = (bool)pack.Model;
                        if (!ok)
                        {
                            this.Dispose();
                            throw new ProxyAuthException(403, "Auth");
                        }
                        break;
                    case Command.GetConfig:
                        _config = (ConfigEntity)pack.Model;
                        break;
                }
            }
        }

        public void FormatDrive()
        {
            base.CheckDisposed();

            _client.Client.Send(new PackModel()
            {
                Cmd = Command.Format,
            });
        }
    }
}