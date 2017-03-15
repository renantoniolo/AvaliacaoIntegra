﻿using System;
using System.Threading.Tasks;

namespace AvaliacaoIntegra
{
	public interface IAlertService
	{
		Task ShowAsync(string title, string message, string buttonOk);
		Task ShowAsync(string title, string message, string buttonOk, string buttonCancel);
	}
}
