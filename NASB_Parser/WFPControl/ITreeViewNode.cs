using System;
using System.Collections.Generic;
using NASB_Parser.WFPControl;

namespace NASB_Parser {

	public interface ITreeViewNode {
		public abstract NASBTreeViewNode toTreeViewNode(string label);
		public abstract NASBTreeViewNode toTreeViewNode();

		public abstract Dictionary<string, Type> requisites();
	}
}