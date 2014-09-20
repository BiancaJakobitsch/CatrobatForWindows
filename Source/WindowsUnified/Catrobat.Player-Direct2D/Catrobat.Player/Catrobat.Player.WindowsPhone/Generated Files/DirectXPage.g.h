﻿

#pragma once
//------------------------------------------------------------------------------
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//------------------------------------------------------------------------------

namespace Windows {
    namespace UI {
        namespace Xaml {
            namespace Controls {
                ref class SwapChainPanel;
                ref class CommandBar;
                ref class AppBarButton;
            }
        }
    }
}

namespace Catrobat_Player
{
    partial ref class DirectXPage : public ::Windows::UI::Xaml::Controls::Page, 
        public ::Windows::UI::Xaml::Markup::IComponentConnector
    {
    public:
        void InitializeComponent();
        virtual void Connect(int connectionId, ::Platform::Object^ target);
    
    private:
        bool _contentLoaded;
    
        private: ::Windows::UI::Xaml::Controls::SwapChainPanel^ swapChainPanel;
        private: ::Windows::UI::Xaml::Controls::CommandBar^ PlayerAppBar;
        private: ::Windows::UI::Xaml::Controls::AppBarButton^ Restart;
        private: ::Windows::UI::Xaml::Controls::AppBarButton^ Play;
        private: ::Windows::UI::Xaml::Controls::AppBarButton^ Screenshot;
        private: ::Windows::UI::Xaml::Controls::AppBarButton^ EnableAxes;
    };
}

