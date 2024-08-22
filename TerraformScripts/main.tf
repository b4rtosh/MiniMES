
# create new resource group
resource "azurerm_resource_group" "rg" {
    name = var.rg-name
    location = var.rg-location
}

# create azure app service plan
resource "azurerm_app_service_plan" "appserviceplan" {
    name                = "${azurerm_resource_group.rg.name}-plan"
    location            = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name
    
  # linux as host
    kind                = "Linux"
    reserved            = true

    sku {
        tier = "Basic"
        size = "B1"
    }
}
# Create storage account for the docker compose file
resource "azurerm_storage_account" "sa" {
    name                     = "dockercomposesa"
    resource_group_name      = azurerm_resource_group.rg.name
    location                 = azurerm_resource_group.rg.location
    account_tier             = "Standard"
    account_replication_type = "LRS"
}

# Create a storage container to hold the Docker Compose file
resource "azurerm_storage_container" "dockercompose" {
    name                  = "docker-compose"
    storage_account_name  = azurerm_storage_account.sa.name
    container_access_type = "private"
}

# Upload Docker Compose file to the storage container
resource "azurerm_storage_blob" "dockercomposeblob" {
    name                   = "docker-compose.yaml"
    storage_account_name   = azurerm_storage_account.sa.name
    storage_container_name = azurerm_storage_container.dockercompose.name
    type                   = "Block"
    source                 = "./docker-compose.yaml"
}

resource "azurerm_app_service" "appservice" {
    name = "${azurerm_resource_group.rg.name}-app"
    location = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name
    app_service_plan_id = azurerm_app_service_plan.appserviceplan.id

    site_config {
        linux_fx_version = "COMPOSE|${azurerm_storage_blob.dockercomposeblob.url}"
    }

    app_settings = {
        WEBSITES_ENABLE_APP_SERVICE_STORAGE = "false"
        DOCKER_REGISTRY_SERVER_URL          = "https://index.docker.io/v1/"
        DOCKER_REGISTRY_SERVER_USERNAME     = var.dockerhub_username
        DOCKER_REGISTRY_SERVER_PASSWORD     = var.dockerhub_password
    }
}


# resource "azurerm_resource_group" "rg" {
#   name = "minimesResourceGroup"
#   location = "polandcentral"
# }
# 
# # Create a container group for the Azure Container Instances
# resource "azurerm_container_group" "containers" {
#   name = "minimesContainerGroup"
#   location = azurerm_resource_group.rg.location
#   resource_group_name = azurerm_resource_group.rg.name
#   os_type = "Linux"
#   ip_address_type = "Public"
#   
#   container {
#     name = "minimes-server"
#     image = "b4rtosh/minimes:server"
#     cpu    = 0.5
#     memory = 1.5
#     ports {
#       port = 5001
#       protocol = "TCP"
#     }
#   }
#   
#   container {
#     name = "minimes-front"
#     image = "b4rtosh/minimes:front"
#     cpu = 0.5
#     memory = 1.5
#     ports {
#       port = 5174
#       protocol = "TCP"
#     }
#   }
#   
#   container {
#     name = "sql-server"
#     image = "b4rtosh/minimes:sql"
#     cpu = 1.0
#     memory = 2
#     environment_variables = {
#       ACCEPT_EULA = "Y"
#       SA_PASSWORD = "zaq1@WSX"
#     }
#     ports {
#       port = 1433
#       protocol = "TCP"
#     }
#   }
#   
#   tags = {
#     environment = "production"
#   }
# }
