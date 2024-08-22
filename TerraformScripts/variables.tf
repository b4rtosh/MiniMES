variable "rg-name" {
  default = "mini-mes-rg"
}

variable "rg-location"{
    default = "polandcentral"
}

variable "client_id" {}
variable "client_secret" {
  sensitive = true
}
variable "tenant_id" {}
variable "subscription_id" {}

variable "dockerhub_username" {}
variable "dockerhub_password" {
  sensitive = true
}