   M S B A M L   `   `   `  ����  	Pluto.Wpf7    1Pluto.Wpf.Views.Dialogs.CreateOrEditSubjectDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   O KWPFLocalizeExtension, Version=3.3.1.0, Culture=neutral, PublicKeyToken=null2lex(http://wpflocalizeextension.codeplex.com  5   	   4  .WPFLocalizeExtension.Engine.LocalizeDictionary    DesignCulture$  hu-HU��5   	   =  7WPFLocalizeExtension.Providers.ResxLocalizationProvider   DefaultAssembly$ 	Pluto.Wpf��5	   	      DefaultDictionary$ Strings��5
   	    � WindowStartupLocation$ CenterScreen=�5   !    � 
ResizeMode$ NoResize=�5   	   $	��350��5   	   $	��200��6    � Title 5   	   �� *Title+��5      �� 5   
      	LightBlue �� Color# [  6    � 	Resources 5       �� 
TargetType  buttonBaseStyle	 �� BasedOn
 �� Property �� Value  labelBaseStyle  textboxBaseStyle��%  '��       7  '�� �     7  '�� �     7  �� 5   
   " ��6   8	   .�5      �� 
 � ��$ 5q�6'   �� 5      
 � ��$ 14(�6)   �� 5      
 � ��$ 70��6&   5      �� 5   
   " ��6   8	   6,   �� 5   
   " ��6   8	   6.   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       $��* �6   �� 5!      $
��auto �6   .+�5$   
   ��   pageTitleStyle#��[ 5%      ��5$      �� *Title+5%      �� 5'   
   $��1��6   $��Center=�5(      .+�5)      �  � ColumnDefinitions 5*      �� 5+      $
��auto �6'   $��70��64   �� 5,       5.      �� 5/      �� 50      .+�53      �� $��0��6   $��0��6(   $��16(�55      ��54      2  ,WPFLocalizeExtension.Extensions.LocExtension  *SubjectDialog_Name+55      �� 56      $��1��6   $��0��6*   ��57      �� *SubjectName+ �� Mode$ TwoWay=��� 59      $��0��6   $��1��6(   $��16(�5;      ��5:        *SubjectDialog_Credit+5;      �� 5<      -   5        $��tbCredit��5>      $��1��5<      $��1��6*   ��5=      �� *SubjectCredit+$ TwoWay=�5>      5?      5@      �� 5B   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�5C      .+�5D      �� $��0��6   $��Right=�6%   ��6A   �� *ButtonContent+��6c   �� *CreateSaveCommand+�� 5E      $��1��6   $
��Left=�6%   ��6@     *SubjectDialog_Back+��6g   �� *BackCommand+5F      5G      5I      