   M S B A M L   `   `   `  ����  	Pluto.Wpf4    .Pluto.Wpf.Views.Dialogs.CreateOrEditTermDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   O KWPFLocalizeExtension, Version=3.3.1.0, Culture=neutral, PublicKeyToken=null2lex(http://wpflocalizeextension.codeplex.com  5   	   4  .WPFLocalizeExtension.Engine.LocalizeDictionary    DesignCulture$  hu-HU��5   	   =  7WPFLocalizeExtension.Providers.ResxLocalizationProvider   DefaultAssembly$ 	Pluto.Wpf��5   	      DefaultDictionary$ Strings��5	   	    � WindowStartupLocation$ CenterScreen=�5   !    � 
ResizeMode$ NoResize=�5   	   $	��300��5   	   $	��200��6    � Title 5   	   �� *Title+��5      �� 5   
      	LightBlue �� Color# [  6    � 	Resources 5       �� 
TargetType  buttonBaseStyle	 �� BasedOn
 �� Property �� Value  labelBaseStyle  textblockFont  lightTextColorBrush  checkboxBaseStyle(  "System.Windows.Controls.DatePicker  datepickerBaseStyle��%�  '��       7  '�� �     7  '�� �     7  7  '�� �     7  '  !    7  �� 5   
   " ��6   8	   .�5      �� 
 � ��$ 5q�6'   �� 5      
 � ��$ 14(�6)   �� 5      
 � ��$ 70��6&   5      �� 5   
   " ��6   8	   6,   �� 5   
   " ��6   8	   .�5      �� 
 � ��8  6+   5      �� 5   
   " ��6   8	   6/   �� 5   
   "  6   8	   61   5      .��5!      �  � RowDefinitions 5"   
   �� 5#      $
��auto �6   $��30��6*   �� 5$      $
��auto �6   $��30��6*   �� 5%      $��* �6   �� 5&      $
��auto �6   .+�5)   
   �� $��Center=�6   $��Center=�5*      $��20(�5+      �� 5,      �6   �� *
TermName+ �� Mode$ OneWay=� �� 5-      $�. ��6    �� 5.      �6   2  ,WPFLocalizeExtension.Extensions.LocExtension  *
Label_Term+5/      �� 51   
   -   5        $��cbActive��51      $��1��6#   $��Center=�52      $��Center=�60   $��16(�54      ��51   0     *TermDialog_Checkbox_Active+ d� 	IsChecked 53      �� *TermIsActive+$ TwoWay=�54      � 56   
   $��2��6   $��Center=�6    57      �� 58      $��* �6    �� 59      $��* �6     � ColumnDefinitions 5;      �� 5<      $
��auto �6#   �� 5=      $��* �6#   .+�5A      �� $��0��6   $��0��6!   $��16(�5C      ��5B        *TermDialog_StartDate+5C        5D      $��0��6   $��1��6&      SelectedDate 5E      �� *SelectedStartDate+{�5F      ��  �� ElementName$ cbActive�� �� Path$ 	IsChecked��� 5H      $��1��6   $��0��6!   $��16(�5J      ��5I        *TermDialog_EndDate+5J        5K      $��1��6   $��1��6&    5L      �� *SelectedEndDate+{�5M      �� $ cbActive��$ 	IsChecked�5N      �� 5P   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�5Q      .+�5R      �� $��0��6   $��Right=�6%   ��6A   �� *ButtonContent+��6c   �� *CreateSaveCommand+�� 5S      $��1��6   $
��Left=�6%   ��6@     *TermDialog_Back+��6d   �� *BackCommand+5T      5U      5W      