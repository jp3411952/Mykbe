﻿/* 
 PureMVC C# Port by Andy Adamczak <andy.adamczak@puremvc.org>, et al.
 PureMVC - Copyright(c) 2006-08 Futurescale, Inc., Some rights reserved. 
 Your reuse is governed by the Creative Commons Attribution 3.0 License 
*/
using System;
using System.Reflection;

using PureMVC.Patterns;

namespace PureMVC.Interfaces
{
    /// <summary>
    /// The interface definition for a PureMVC Observer
    /// </summary>
    /// <remarks>
    ///     <para>In PureMVC, <c>IObserver</c> implementors assume these responsibilities:</para>
    ///     <list type="bullet">
    ///         <item>Encapsulate the notification (callback) method of the interested object</item>
    ///         <item>Encapsulate the notification context (<c>this</c>) of the interested object</item>
    ///         <item>Provide methods for setting the interested object' notification method and context</item>
    ///         <item>Provide a method for notifying the interested object</item>
    ///     </list>
    ///     <para>PureMVC does not rely upon underlying event models</para>
    ///     <para>The Observer Pattern as implemented within PureMVC exists to support event driven communication between the application and the actors of the MVC triad</para>
    ///     <para>An Observer is an object that encapsulates information about an interested object with a notification method that should be called when an <c>INotification</c> is broadcast. The Observer then acts as a proxy for notifying the interested object</para>
    ///     <para>Observers can receive <c>Notification</c>s by having their <c>notifyObserver</c> method invoked, passing in an object implementing the <c>INotification</c> interface, such as a subclass of <c>Notification</c></para>
    /// </remarks>
	/// <see cref="PureMVC.Interfaces.IView"/>
	/// <see cref="PureMVC.Interfaces.INotification"/>
    public interface IObserver
    {
        /// <summary>
        /// Notify the interested object
        /// </summary>
        /// <param name="notification">The <c>INotification</c> to pass to the interested object's notification method</param>
        void OnNotify<SendEntity, Param>(INotification<SendEntity, Param> notification);

    }
}