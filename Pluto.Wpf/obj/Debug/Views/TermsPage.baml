   M S B A M L   `   `   `  ����D  @Pluto.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Pluto.Wpf.ConvertersPluto.Wpf.Converters  5          Pluto.Wpf.Views.TermsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      P LPrism.Wpf, Version=6.3.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      2	converter"clr-namespace:Pluto.Wpf.Converters  5      O KWPFLocalizeExtension, Version=3.3.1.0, Culture=neutral, PublicKeyToken=null2lex(http://wpflocalizeextension.codeplex.com  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . 4  .WPFLocalizeExtension.Engine.LocalizeDictionary   DesignCulture$ hu-HU��5      =  7WPFLocalizeExtension.Providers.ResxLocalizationProvider   DefaultAssembly$ 	Pluto.Wpf��5	         DefaultDictionary$ Strings��5
       � 	Resources 5      4   .Pluto.Wpf.Converters.BoolToVisibilityConverter    BooleanToVisibilityConverter �� 
TargetType  buttonBaseStyle �� BasedOn �� Property �� Value  textblockBaseStyle  lightTextColorBrush  labelBaseStyle  checkboxBaseStyle	 �� 
TargetType
 �� CornerRadius �� Triggers P� Property P� Value  DarkBlue �� Color��%�  &	        '��      7  '�� �     7  7  '�� �     7  '�� �     7  '��     7  7  7    5   
   6.   �� 5   
   " ��6   8   .�5      ��  � ��$	 3 5q�6'   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   8   .�5      ��  � ��8  6+   5      �� 5   
   " ��6   8   6,   �� 5   
   " ��6   8   6/   �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ 2 1.5q�6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $��Border��6!   
���   �$	��0.8q�6C   $
 3��6Y   #��z��6j   ._�5       �� $
��10 5q�6/   5!      5"      5$       5&      P� 5'       �@J�IsMouseOver . . �5(      ��  � �� 5)      �� 5*      8  6.   5,      5-      P� 5.       �@��
IsSelected . . �5/      ��  � �� 50      �� 51      8  6.   53      54      56      57      ��59      �� 5:   
     	LightBlue# [ 6   .��5=      � $	��5 0q�6    � RowDefinitions 5>   
   �� 5?      $
��auto �6   $��50��6*   �� 5@      $
��auto �6   �� 5A      $��* �6   .+�5D   
   �  5E      �� 5F      $��* �6    �� 5G      $��* �6    .+�5J      ��   pageTitleStyle#��[ 5K      ��5J      2  ,WPFLocalizeExtension.Extensions.LocExtension  *TermsPage_Title+5K      �� 5L      $��1��6   ��6!     *Label_Loading+y�6C   �� *	IsLoading+ �� 	Converter# [  5M      �� 5O   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�5P      $	��0 4q�5Q      .+�5R      �� ��6     *TermsPage_Button_NewTerm+��6B   �� *NewTermCommand+�� 5S      ��6     *TermsPage_Button_EditTerm+��6C   �� *EditTermCommand+�� 5T      ��6     *!TermsPage_Button_DeleteLastTerm+��6I   �� *DeleteLastTermCommand+�� 5U      ��6     *TermsPage_Button_CloseTerm+��6D   �� *CloseTermCommand+5V      �� 5X   
   $��2��6   
���   �$	��1.5q�5Y   %   $
 10��6;   $��3 0 3 3q�5Z       �� Padding$ 5q�6"   ._�5\      �� $��Stretch=�5_      $��0q�5`      ��5\      �� *Terms+ �� SelectedIndex 5]      �� *SelectedTermIndex+ �� Mode$ TwoWay=� �� SelectedItem 5^      �� *SelectedTerm+$ OneWayToSource=���5a      �� 5b      # [ 6&   ��5e      �� 5f      .R�5g      �  5h      �� 5i   "   �� 5j   "   �� 5k   "   .+�5n      �� $ 
Horizontal=�6)   $��0 0 0 10q�6B   .+�5o   "   �� $��16(�6,   $
��Bold"�6:   $��0 0 40 0q�5p   ,   �� 5q   &   �6*   �� *Name+ �� 5r   &   $�. ��6*    �� 5s   &   �6*     *
Label_Term+5t   #   �� 5u   "   {�.  $��0 0 10 0q�5v   +   ��5u   +     *TermsPage_Checkbox_Active+ d� 	IsChecked 6Y   �� *
IsActive+$ OneWay=�5v   +   �� 5w   "   {�.  $��0 0 10 0q�5x   +   ��5w   +     *TermsPage_Checkbox_Closed+ 6Y   �� *
IsClosed+$ OneWay=�5x   +   �� 5y   "   $��30 0 0 0q�6,   $��Center=�6>   �� 5z   &   �6*   �� *Period.StartDate+ �� StringFormat$ yyyy.MM.dd.�� �� 5{   &   $	� - ��6*    �� 5|   &   �6*   �� *Period.EndDate+$ yyyy.MM.dd.��5}   #   5~      �� 5�      $��1��6(   $��0 0 0 3q�5�   (   �� 5�   "   �6&     *TermsPage_RegisteredCredits+ �� 5�   "   $� ��6&    �� 5�   "   �6&   �� *RegisteredCredits+$ OneWay=�5�      �� 5�      $��2��6+   $��Stretch=�5�   -   ��5�   8   �� *RegisteredSubjects+��5�   "   �� 5�   &   .R�5�   *   � $
��20 3q�6/    � ColumnDefinitions 5�   .   �� 5�   2   �� 5�   2   �� 5�   2   .+�5�   .   �� $��0��68   ��6H   �� *Name+�� 5�   .   $��1��68   �� 5�   2   �66   �� *Credit+ �� 5�   2   $� ��66    �� 5�   2   �66     *TermsPage_Credits+5�   /   �� 5�   .   $��2��67   {�.  ��6G     *Checkbox_Completed+ 6n   �� *IsCompleted+5�   9   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      