   M S B A M L   `   `   `  ����  	Pluto.Wpf:    4Pluto.Wpf.Views.Dialogs.CreateOrEditAttendanceDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   O KWPFLocalizeExtension, Version=3.3.1.0, Culture=neutral, PublicKeyToken=null2lex(http://wpflocalizeextension.codeplex.com  5   	   4  .WPFLocalizeExtension.Engine.LocalizeDictionary    DesignCulture$  hu-HU��5   	   =  7WPFLocalizeExtension.Providers.ResxLocalizationProvider   DefaultAssembly$ 	Pluto.Wpf��5   	      DefaultDictionary$ Strings��5	   	    � WindowStartupLocation$ CenterScreen=�5   !    � 
ResizeMode$ NoResize=�5   	   $	��400��5   	   $	��210��6    � Title 5   	   �� *Title+��5      �� 5   
      	LightBlue �� Color# [  6    � 	Resources 5       �� 
TargetType  buttonBaseStyle	 �� BasedOn
 �� Property �� Value  labelBaseStyle  textboxBaseStyle(  "System.Windows.Controls.DatePicker  datepickerBaseStyle��%  '��       7  '�� M     7  '�� �     7  '  �     7  �� 5   
   " ��6   8	   .�5      �� 
 � ��$ 14(�6)   5      �� 5   
   " ��6   8	   .�5      �� 
 � ��$ 16(�6)   5      �� 5   
   " ��6   8	   6.   �� 5   
   "  6   8	   61   5      .��5      �  � RowDefinitions 5   
   �� 5       $
��auto �6   �� 5!      $��* �6   �� 5"      $
��auto �6   .+�5%   
   � $��1��6   $��5q�5&       5'      �� 5(      $
��auto �6    �� 5)      $
��auto �6    �� 5*      $
��auto �6    �� 5+      $
��auto �6     � ColumnDefinitions 5-      �� 5.      $
��auto �6#   �� 5/      $��* �6#   .+�52      �� ��6   2  ,WPFLocalizeExtension.Extensions.LocExtension  *AttendanceDialog_Name+�� 53      $��1��6   ��6&   �� *AttendanceName+ �� Mode$ TwoWay=��� 55      $��1��6   $��0��6!   ��61     *AttendanceDialog_Date+  56      $��1��6   $��1��6&      SelectedDate 66   �� *Date+�� 58      $��2��6   $��0��6!   ��61     *AttendanceDialog_StartTime+�� 59      $��2��6   $��1��6&    �� Orientation$ 
Horizontal=�5:      .+�5;      �� {�.  $��0 0 5 0q�5<      ��5;      �� *	StartTime+ �� StringFormat$ hh��$ OneWay=�5<      �� 5=      $��˄��6   ��6%   �� *IncreaseStartTimeHourCommand+�� 5>      $��˅��6   ��6%   �� *DecreaseStartTimeHourCommand+�� 5@      {�.  $��15 0 5 0q�5A      ��5@      �� *	StartTime+$ mm��$ OneWay=�5A      �� 5B      $��˄��6   ��6%   �� * IncreaseStartTimeMinuteCommand+�� 5C      $��˅��6   ��6%   �� * DecreaseStartTimeMinuteCommand+�� 5E      $
��10 0q�5F      ��5E        *AttendanceDialog_TimeFormat+5F      5G      �� 5I      $��3��6   $��0��6!   ��61     *AttendanceDialog_EndTime+�� 5J      $��3��6   $��1��6&   $ 
Horizontal=�5K      .+�5L      �� {�.  $��0 0 5 0q�5M      ��5L      �� *	EndTime+$ hh��$ OneWay=�5M      �� 5N      $��˄��6   ��6%   �� *IncreaseEndTimeHourCommand+�� 5O      $��˅��6   ��6%   �� *DecreaseEndTimeHourCommand+�� 5Q      {�.  $��15 0 5 0q�5R      ��5Q      �� *	EndTime+$ mm��$ OneWay=�5R      �� 5S      $��˄��6   ��6%   �� *IncreaseEndTimeMinuteCommand+�� 5T      $��˅��6   ��6%   �� *DecreaseEndTimeMinuteCommand+�� 5V      $
��10 0q�5W      ��5V        *AttendanceDialog_TimeFormat+5W      5X      5Y      �� 5[   
   $��3��6   $ 
Horizontal=�6"   $��Center=�5\      .+�5]      �� $��0��6   $��Right=�6%   $��70��5`      $��5q�5a      ��5^      �� *ButtonContent+��5_      �� *AddSaveCommand+5a      �� 5b      $��1��6   $
��Left=�6%   $��70��5e      $��5q�5f      ��5c        *AttendanceDialog_Back+��5d      �� *BackCommand+5f      5g      5h      5i      