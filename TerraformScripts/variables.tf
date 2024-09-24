variable "rg-name" {
  type = string
  default = "mini-mes-rg"
}

variable "rg-location"{
  type = string
  default = "polandcentral"
}

variable "client_id" {}
variable "client_secret" {
  sensitive = true
}
variable "tenant_id" {}
variable "subscription_id" {}

variable "server_name" {
    type = string
    default = "minimes-server"
}
variable "server_image" {
  type = string
  default = "b4rtosh/minimes-server:latest"
}

variable "server_port" {
  type = number
  default = 5001
}

variable "sql_name" {
    type = string
    default = "sql-server"
}

variable "sql_image"{
  type = string
  default = "b4rtosh/minimes-sql:latest"
}

variable "sql_port" {
  type = number
  default = 1433
}

variable "sql_password" {
  type = string
  sensitive = true
}

variable "front_name" {
    type = string
    default = "minimes-front"
}

variable "front_image" {
  type = string
  default = "b4rtosh/minimes-front:latest"
}

variable "front_port" {
  type = number
  default = 80
}


