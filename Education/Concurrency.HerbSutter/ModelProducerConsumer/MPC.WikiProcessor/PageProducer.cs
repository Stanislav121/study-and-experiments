using System;
using System.Xml;
using System.IO;
using System.Collections.Concurrent;

namespace MPC.WikiProcessor
{
    class PageProducer : IDisposable
    {
        private readonly XmlReader _reader;
        private readonly long _pagesToProcess;
        private long _pageCount;
        private readonly BlockingCollection<string> _transmitter;

        public PageProducer(string filePath, long pagesToProcess, BlockingCollection<string> transmitter)
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            _reader = XmlReader.Create(fs);
            _pagesToProcess = pagesToProcess;
            _transmitter = transmitter;
        }

        public void Run()
        {
            bool stop = false;
            while (_reader.Read() & !stop)
                switch (_reader.NodeType)
                {
                    case XmlNodeType.Text:
                        _transmitter.Add(_reader.Value);

                        _pageCount++;
                        if (_pageCount == _pagesToProcess)
                        {
                            _transmitter.CompleteAdding();
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
