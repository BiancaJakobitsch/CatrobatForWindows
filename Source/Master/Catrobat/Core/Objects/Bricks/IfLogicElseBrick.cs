﻿using System.Xml.Linq;

namespace Catrobat.Core.Objects.Bricks
{
    public class IfLogicElseBrick : Brick
    {
        private IfLogicBeginBrickReference _ifLogicBeginBrickReference;
        internal IfLogicBeginBrickReference IfLogicBeginBrickReference
        {
            get { return _ifLogicBeginBrickReference; }
            set
            {
                if (_ifLogicBeginBrickReference == value)
                    return;

                _ifLogicBeginBrickReference = value;
                RaisePropertyChanged();
            }
        }

        public IfLogicBeginBrick IfLogicBeginBrick
        {
            get
            {
                if (_ifLogicBeginBrickReference == null)
                    return null;

                return _ifLogicBeginBrickReference.IfLogicBeginBrick;
            }
            set
            {
                if (_ifLogicBeginBrickReference == null)
                    _ifLogicBeginBrickReference = new IfLogicBeginBrickReference();

                if (_ifLogicBeginBrickReference.IfLogicBeginBrick == value)
                    return;

                _ifLogicBeginBrickReference.IfLogicBeginBrick = value;

                if (value == null)
                    _ifLogicBeginBrickReference = null;

                RaisePropertyChanged();
            }
        }

        private IfLogicEndBrickReference _ifLogicEndBrickReference;
        internal IfLogicEndBrickReference IfLogicEndBrickReference
        {
            get { return _ifLogicEndBrickReference; }
            set
            {
                if (_ifLogicEndBrickReference == value)
                    return;

                _ifLogicEndBrickReference = value;
                RaisePropertyChanged();
            }
        }

        public IfLogicEndBrick IfLogicEndBrick
        {
            get
            {
                if (_ifLogicEndBrickReference == null)
                    return null;

                return _ifLogicEndBrickReference.IfLogicEndBrick;
            }
            set
            {
                if (_ifLogicEndBrickReference == null)
                    _ifLogicEndBrickReference = new IfLogicEndBrickReference();

                if (_ifLogicEndBrickReference.IfLogicEndBrick == value)
                    return;

                _ifLogicEndBrickReference.IfLogicEndBrick = value;

                if (value == null)
                    _ifLogicEndBrickReference = null;

                RaisePropertyChanged();
            }
        }


        public IfLogicElseBrick() {}

        public IfLogicElseBrick(XElement xElement) : base(xElement) { }

        internal override void LoadFromXML(XElement xRoot)
        {
            if (xRoot.Element("ifBeginBrick") != null)
            {
                _ifLogicBeginBrickReference = new IfLogicBeginBrickReference(xRoot.Element("ifBeginBrick"));
            }
            if (xRoot.Element("ifEndBrick") != null)
            {
                _ifLogicEndBrickReference = new IfLogicEndBrickReference(xRoot.Element("ifEndBrick"));
            }
        }

        internal override XElement CreateXML()
        {
            var xRoot = new XElement("ifLogicElseBrick");

            if(_ifLogicBeginBrickReference != null)
                xRoot.Add(_ifLogicBeginBrickReference.CreateXML());

            if(_ifLogicEndBrickReference != null)
                xRoot.Add(_ifLogicEndBrickReference.CreateXML());

            return xRoot;
        }

        internal override void LoadReference()
        {
            if (_ifLogicBeginBrickReference.IfLogicBeginBrick == null)
                _ifLogicBeginBrickReference.LoadReference();
            if (_ifLogicEndBrickReference.IfLogicEndBrick == null)
                _ifLogicEndBrickReference.LoadReference();
        }

        public override DataObject Copy()
        {
            var newBrick = new IfLogicElseBrick();

            newBrick.IfLogicBeginBrickReference = _ifLogicBeginBrickReference.Copy() as IfLogicBeginBrickReference;
            newBrick.IfLogicEndBrickReference = _ifLogicEndBrickReference.Copy() as IfLogicEndBrickReference;

            return newBrick;
        }

        public override bool Equals(DataObject other)
        {
            throw new System.NotImplementedException();
        }
    }
}