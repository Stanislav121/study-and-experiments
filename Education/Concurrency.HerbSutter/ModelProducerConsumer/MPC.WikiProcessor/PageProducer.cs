using System;
using System.Xml;
using System.IO;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MPC.WikiProcessor
{
    class PageProducer : IDisposable
    {
        private readonly XmlReader _reader;
        private readonly long _pagesToProcess;
        private long _pageCount;
        private readonly BlockingCollection<string> _transmitter;
        public readonly IList<string> Lines;

        public PageProducer(string filePath, long pagesToProcess, BlockingCollection<string> transmitter)
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            _reader = XmlReader.Create(fs);
            _pagesToProcess = pagesToProcess;
            _transmitter = transmitter;
            Lines = new List<string>();
        }

        public void Run()
        {
            bool stop = false;
            while (_reader.Read() & !stop)
                switch (_reader.NodeType)
                {
                    case XmlNodeType.Text:
                        string line = _reader.Value;
                        Lines.Add(line);
                        //Console.WriteLine($"Producer {line}");
                        _transmitter.Add(line);

                        _pageCount++;
                        if (_pageCount == _pagesToProcess)
                        {
                            _transmitter.CompleteAdding();
                            //_transmitter.Enqueue("StasBulovskiicbgvnhbvmb,mn34345365465");
                            stop = true;

                        }
                        break;
                }
        }

        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}
