﻿using System;
using PDFPatcher.Processor;
using System.Windows.Forms;

namespace PDFPatcher.Functions.Editor
{
	sealed class BookmarkPageCommand : IEditorCommand
	{
		int _number;

		public BookmarkPageCommand (int number) {
			_number = number;
		}

		public void Process (Controller controller, params string[] parameters) {
			var n = _number;
			if (_number == 0) {
				using (var form = new ShiftPageNumberEntryForm ()) {
					if (form.ShowDialog () != DialogResult.OK || form.ShiftNumber == 0) {
						return;
					}
					n = form.ShiftNumber;
				}
			}
			controller.ProcessBookmarks (new ChangePageNumberProcessor (n, false, true));
		}

	}
}
