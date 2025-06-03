pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                // Jenkins will clone your repo automatically
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                sh '/usr/local/share/dotnet/dotnet dotnet restore AutomationProject.csproj'
            }
        }

        stage('Build') {
            steps {
                sh '/usr/local/share/dotnet/dotnet dotnet build AutomationProject.csproj --configuration Release'
            }
        }

        stage('Test') {
            steps {
                sh '/usr/local/share/dotnet/dotnet dotnet test AutomationProject.csproj --configuration Release'
            }
        }
    }
}
