# create new resource group
resource "azurerm_resource_group" "rg" {
  name     = var.rg-name
  location = var.rg-location
}

resource "azurerm_container_group" "container" {
  name                = "minimes-container"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  os_type             = "Linux"
  
  ip_address_type     = "Public"
  
#   container {
#     name   = var.front_name
#     image  = var.front_image
#     cpu    = 0.5
#     memory = "1.5"
#     ports {
#       port     = var.front_port
#       protocol = "TCP"
#     }
#   }
# 
#   container {
#     name   = var.server_name
#     image  = var.server_image
#     cpu    = 0.5
#     memory = "1.5"
#     ports {
#       port     = var.server_port
#       protocol = "TCP"
#     }
#   }

  container {
    name   = var.sql_name
    image  = var.sql_image
    cpu    = 0.5
    memory = "1.5"
    ports {
      port     = var.sql_port
      protocol = "TCP"
    }
    environment_variables = {
      MSSQL_SA_PASSWORD = var.sql_password
      ACCEPT_EULA = "Y"
    }
    
    
  }
  tags = {
    environment = "testing"
  }
}



# # configure log analytics workspace
# resource "azurerm_log_analytics_workspace" "law" {
#   name                = "minimes-law"
#   location            = azurerm_resource_group.rg.location
#   resource_group_name = azurerm_resource_group.rg.name
#   sku                 = "PerGB2018"
# }
# 
# #  configure azure container app environment
# resource "azurerm_container_app_environment" "aca_env" {
#   name                       = "minimes-app-env"
#   location                   = azurerm_resource_group.rg.location
#   resource_group_name        = azurerm_resource_group.rg.name
#   log_analytics_workspace_id = azurerm_log_analytics_workspace.law.id
# }
# # configure azure container app
# resource "azurerm_container_app" "aca" {
#   name                         = "minimes-app"
#   container_app_environment_id = azurerm_container_app_environment.aca_env.id
#   resource_group_name          = azurerm_resource_group.rg.name
#   revision_mode                = "Single"
# 
#   ingress {
#     target_port = 5001
#     traffic_weight {
#       percentage = 100
#       latest_revision = true
#     }
#   }
#   template {
#     container {
#       name   = var.server_name
#       image  = var.server_image
#       cpu    = 0.5
#       memory = "1Gi"
#     }
#     container {
#       name  = var.sql_name
#       image = var.sql_image
#       cpu   = 0.5
#       memory = "1Gi"
#     }
#     
#   }
# }