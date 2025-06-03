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
                sh 'dotnet restore AutomationProject.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build AutomationProject.csproj --configuration Release'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test AutomationProject.csproj --configuration Release'
            }
        }
    }
}
