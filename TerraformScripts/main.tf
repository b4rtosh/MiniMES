
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
    name                   = "docker-compose.yml"
    storage_account_name   = azurerm_storage_account.sa.name
    storage_container_name = azurerm_storage_container.dockercompose.name
    type                   = "Block"
    source                 = "${path.module}/docker-compose.yml"
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